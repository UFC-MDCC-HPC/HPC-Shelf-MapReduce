using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance
{
	public interface ITaskBindingAdvance : BaseITaskBindingAdvance
	{
	}
	
	public class ITaskPortAdvance 
	{
		public static object READ_CHUNK = new object();
		public static object PERFORM = new object();
		public static object CHUNK_READY = new object();
	}
}