/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.task.TaskPortTypePhases;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsClient;
using br.ufc.mdcc.hpcshelf.mapreduce.task.reducer.TaskBindingReduce;
using br.ufc.mdcc.hpcshelf.mapreduce.environment.MbyN.EnvironmentPortTypeTakePairsServer;
using br.ufc.mdcc.hpcshelf.mapreduce.workflow.Reducer;

namespace br.ufc.mdcc.hpcshelf.mapreduce.workflow.impl.ReducerImpl 
{
	public abstract class BaseIReducerImpl<RF, OMK, OMV, ORK, ORV, C, S, P>: Computation, BaseIReducer<RF, OMK, OMV, ORK, ORV, C, S, P>
		where RF:IReduceFunction<OMK, OMV, ORK, ORV>
		where OMK:IData
		where OMV:IData
		where ORK:IData
		where ORV:IData
		where C:IEnvironmentPortTypeTakePairsClient
		where S:IEnvironmentPortTypeTakePairsServer
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
		private ITaskPort<ITaskPorttypePhases> task_port_reduce = null;

		public ITaskPort<ITaskPorttypePhases> Task_port_reduce
		{
			get
			{
				if (this.task_port_reduce == null)
					this.task_port_reduce = (ITaskPort<ITaskPorttypePhases>) Services.getPort("task_port_reduce");
				return this.task_port_reduce;
			}
		}
		private IKVPair<OMK, ISet<OMV>> input_item = null;

		public IKVPair<OMK, ISet<OMV>> Input_item
		{
			get
			{
				if (this.input_item == null)
					this.input_item = (IKVPair<OMK, ISet<OMV>>) Services.getPort("input_item");
				return this.input_item;
			}
		}
		private RF reduce_function = default(RF);

		protected RF Reduce_function
		{
			get
			{
				if (this.reduce_function == null)
					this.reduce_function = (RF) Services.getPort("reduce_function");
				return this.reduce_function;
			}
		}
		private IClientBase<C> collect_pairs = null;

		protected IClientBase<C> Collect_pairs
		{
			get
			{
				if (this.collect_pairs == null)
					this.collect_pairs = (IClientBase<C>) Services.getPort("collect_pairs");
				return this.collect_pairs;
			}
		}
		private ITaskBindingReduce task_reduce = null;

		protected ITaskBindingReduce Task_reduce
		{
			get
			{
				if (this.task_reduce == null)
					this.task_reduce = (ITaskBindingReduce) Services.getPort("task_reduce");
				return this.task_reduce;
			}
		}
		private IServerBase<S> feed_pairs = null;

		protected IServerBase<S> Feed_pairs
		{
			get
			{
				if (this.feed_pairs == null)
					this.feed_pairs = (IServerBase<S>) Services.getPort("feed_pairs");
				return this.feed_pairs;
			}
		}
		private IKVPair<ORK, ORV> output_item = null;

		public IKVPair<ORK, ORV> Output_item
		{
			get
			{
				if (this.output_item == null)
					this.output_item = (IKVPair<ORK, ORV>) Services.getPort("output_item");
				return this.output_item;
			}
		}
	}
}