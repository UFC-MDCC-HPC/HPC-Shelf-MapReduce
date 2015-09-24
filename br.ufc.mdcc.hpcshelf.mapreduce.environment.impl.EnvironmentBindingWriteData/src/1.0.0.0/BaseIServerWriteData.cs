/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortType;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;

namespace br.ufc.mdcc.hpcshelf.mapreduce.environment.impl.EnvironmentBindingWriteData 
{
	public abstract class BaseIServerWriteData: Synchronizer, BaseIServerBase<IEnvironmentPortTypeSinglePartner>
	{
		private IEnvironmentPortType server_port_type = null;

		protected IEnvironmentPortType Server_port_type
		{
			get
			{
				if (this.server_port_type == null)
					this.server_port_type = (IEnvironmentPortType) Services.getPort("server_port_type");
				return this.server_port_type;
			}
		}
	}
}