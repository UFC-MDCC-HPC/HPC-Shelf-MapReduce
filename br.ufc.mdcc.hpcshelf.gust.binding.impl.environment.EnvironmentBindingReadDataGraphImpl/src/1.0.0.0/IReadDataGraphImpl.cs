using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.gust.binding.environment.EnvironmentBindingReadDataGraph;//
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBaseDirect;
using System.Threading;
using System.Collections.Generic;

namespace br.ufc.mdcc.hpcshelf.gust.binding.impl.environment.EnvironmentBindingReadDataGraphImpl
{
	public class IReadDataGraphImpl<S>: BaseIReadDataGraphImpl<S>, IReadDataGraph<S>
		where S:IPortTypeDataSourceGraphInterface {
		public override void main(){ }

		private Thread thread_file_reader = null;

		public override void after_initialize() {
			Client.IsEmptyAction = ask_for_next_item;
			startReadSource ();
		}

		private void ask_for_next_item() {
			e.Set ();
		}

		AutoResetEvent e = new AutoResetEvent(false);
		ManualResetEvent client_ok = new ManualResetEvent(false); 
		AutoResetEvent server_ok = new AutoResetEvent(false);

		public void startReadSource() {
			thread_file_reader = new Thread (file_reader);
			thread_file_reader.Start ();
		}

		private IPortTypeIterator client = null;
		public IPortTypeIterator Client { 
			get {
				client_ok.WaitOne ();
				return client; 
			} 
		}
		private S server = default(S);
		public S Server { 
			set { 
				server = value; 
				client = (IPortTypeIterator)server.IteratorInstance; 
				server_ok.Set (); 
				client_ok.Set (); 
			} 
		}

		private static int CHUNK_SIZE = 50;

		int counter_write_chunk = 0;
		int counter_write_global = 0;

		private void file_reader() {
			IEnumerable<object> enumerable_obj = server.fetchContentsKeyValue ();
			foreach (object item_kv in enumerable_obj) {
				e.WaitOne (); 
				client.put(item_kv);

				counter_write_chunk++;
				counter_write_global++;

				if (counter_write_chunk >= CHUNK_SIZE) {
					Console.WriteLine ("NEW CHUNK size=" + counter_write_chunk);
					counter_write_chunk = 0;
					client.finish ();
				}
			}
			// CLOSE THE LAST CHUNK.
			if (counter_write_chunk > 0)
				client.finish ();

			// SEND ITERATION TERMINATION CHUNK.
			client.finish ();

			// SEND COMPUTATION TERMINATION CHUNK.
			client.finish ();

			Console.WriteLine ("FINISHING READING DATA SOURCE");
		}
	}
}
