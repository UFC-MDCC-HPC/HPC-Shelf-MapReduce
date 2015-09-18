using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer
{
	public interface IReducer<RF, ORV, ORK, OMV, OMK> : BaseIReducer<RF, ORV, ORK, OMV, OMK>
		where RF:IReduceFunction<ORV, ORK, OMV, OMK>
		where ORV:IData
		where ORK:IData
		where OMV:IData
		where OMK:IData
	{
	}
}