/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.channel.Binding;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeDataSinkInterface;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.environment.EnvironmentBindingWriteData;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface BaseISplitterWriteSink<M3,OKey,OValue> : ISynchronizerKind 
		where M3:IMaintainer
		where OKey:IData
		where OValue:IData
	{
		IWriteData<IPortTypeDataSinkInterface> Sink { get; }
		ITaskBindingData Task_binding_data { get; }
	}
}