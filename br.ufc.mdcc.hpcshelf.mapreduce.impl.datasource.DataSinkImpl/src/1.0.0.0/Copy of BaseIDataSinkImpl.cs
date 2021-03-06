/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.datasource.DataSink;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.datasource.DataSinkImpl 
{
	public abstract class BaseIDataSinkImpl<P>: Computation, BaseIDataSink<P>
		where P:IPlatform
	{
		private P platform = default(P);

		protected P Platform
		{
			get
			{
				if (this.platform == null)
					this.platform = (P) Services.getPort("platform");
				return this.platform;
			}
		}

		private IServerBase<IPortTypeDataSinkInterface> writer = null;

		protected IServerBase<IPortTypeDataSinkInterface> Writer
		{
			get
			{
				if (this.writer == null)
					this.writer = (IServerBase<IPortTypeDataSinkInterface>) Services.getPort("writer");
				return this.writer;
			}
		}
	}
}