/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.task.TaskPortTypeAdvance;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.ShufflerImpl 
{
	public abstract class BaseIShufflerReduceFeederImpl<OMK, OMV>: Synchronizer, BaseIShufflerReduceFeeder<OMK, OMV>
		where OMK:IData
		where OMV:IData	
	{
		static protected int FACET_MAP = 1;
		static protected int FACET_REDUCE = 0;

		private ITaskBindingAdvance task_binding_shuffle = null;

		protected ITaskBindingAdvance Task_binding_shuffle
		{
			get
			{
				if (this.task_binding_shuffle == null)
					this.task_binding_shuffle = (ITaskBindingAdvance) Services.getPort("task_binding_shuffle");
				return this.task_binding_shuffle;
			}
		}

		private ITaskPort<ITaskPortTypeAdvance> task_port_shuffle = null;

		public ITaskPort<ITaskPortTypeAdvance> Task_port_shuffle
		{
			get
			{
				if (this.task_port_shuffle == null)
					this.task_port_shuffle = (ITaskPort<ITaskPortTypeAdvance>) Services.getPort("task_port_shuffle");
				return this.task_port_shuffle;
			}
		}

		private IServerBase<IPortTypeIterator> feed_pairs = null;

		protected IServerBase<IPortTypeIterator> Feed_pairs
		{
			get
			{
				if (this.feed_pairs == null)
					this.feed_pairs = (IServerBase<IPortTypeIterator>) Services.getPort("feed_pairs");
				return this.feed_pairs;
			}
		}

		private IChannel shuffler_channel = null;

		public IChannel Shuffler_channel
		{
			get
			{
				if (this.shuffler_channel == null)
					this.shuffler_channel = (IChannel) Services.getPort("shuffler_channel");
				return this.shuffler_channel;
			}
		}

		private IIterator<IKVPair<OMK,IIterator<OMV>>> output = null;
		protected IIterator<IKVPair<OMK,IIterator<OMV>>> Output {
			get {
				if (this.output == null)
					this.output = (IIterator<IKVPair<OMK,IIterator<OMV>>>)Services.getPort("output");
				return this.output;
			}
		}

		private IIterator<OMV> value_factory = null;
		protected IIterator<OMV> Value_factory {
			get {
				if (this.value_factory == null)
					this.value_factory = (IIterator<OMV>)Services.getPort("value_factory");
				return this.value_factory;
			}
		}
	}
}