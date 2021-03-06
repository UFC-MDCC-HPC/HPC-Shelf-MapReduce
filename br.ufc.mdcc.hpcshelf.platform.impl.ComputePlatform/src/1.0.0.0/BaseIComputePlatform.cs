/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost;
using br.ufc.mdcc.hpcshelf.platform.Platform;

namespace br.ufc.mdcc.hpcshelf.platform.impl.ComputePlatform 
{
	public abstract class BaseIComputePlatform<M>: br.ufc.pargo.hpe.kinds.Environment, BaseIProcessingNode<M>
		where M:IComputeHost
	{
		private M maintainer = default(M);

		protected M Maintainer
		{
			get
			{
				if (this.maintainer == null)
					this.maintainer = (M) Services.getPort("maintainer");
				return this.maintainer;
			}
		}
	}
}