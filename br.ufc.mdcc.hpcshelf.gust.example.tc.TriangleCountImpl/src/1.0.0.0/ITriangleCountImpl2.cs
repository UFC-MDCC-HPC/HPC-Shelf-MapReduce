using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.hpcshelf.gust.example.tc.TriangleCount;
using br.ufc.mdcc.hpcshelf.gust.graph.UndirectedGraph;
using br.ufc.mdcc.hpcshelf.gust.graph.container.DataContainerV;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.gust.graph.Edge;
using br.ufc.mdcc.hpcshelf.gust.graph.EdgeBasic;
using br.ufc.mdcc.hpcshelf.gust.example.tc.DataTriangle;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;

namespace br.ufc.mdcc.hpcshelf.gust.example.tc.TriangleCountImpl {
	public class ITriangleCountImpl : BaseITriangleCountImpl, ITriangleCount {

		private IUndirectedGraphInstance<IVertexBasic, IEdgeBasic<IVertexBasic>, int, IEdgeInstance<IVertexBasic, int>> g = null;
		private int[] partition = null;
		private bool[]  partition_own = null;
		private int partid = 0;
		private int partition_size = 0;
		private int count = 0;
		//private IDictionary<int, IList<KeyValuePair<int,int>>> triangles = new Dictionary<int, IList<KeyValuePair<int,int>>>();
		public bool isGhost(int v){ return !partition_own[this.partition [v - 1]]; }

		public override void main() { this.input_messages (); }
		#region Create Undirected Graph
		public void graph_creator(IInputFormatInstance gif){
			if (partition_own==null){
				partition = gif.PartitionTABLE;
				partid = gif.PARTID;
				partition_size = gif.PARTITION_SIZE;
				g = Graph.newInstance (gif.VSIZE); // pega-se uma instancia do graph, com vertices do tipo inteiro, com tamanho previsto VSIZE
				g.DataContainer.AllowingLoops = false; // não serão premitidos laços
				g.DataContainer.AllowingMultipleEdges = false; // não serão permitidas múltiplas arestas
				partition_own = new bool[partition_size];
			}
			partition_own [gif.PARTID] = true;
			for (int i = 0; i < gif.ESIZE;) {
				if (gif.Target [i] != 0) { // Será usada a forma canonica: i->j, onde i<j, i>0 j>0
					int s = gif.Source [i] < gif.Target [i] ? gif.Source [i] : gif.Target [i];
					int t = gif.Target [i] > gif.Source [i] ? gif.Target [i] : gif.Source [i];
					g.addVertex (s);
					g.addVertex (t);
					g.noSafeAdd (s, t);
					i++;
				}
			}
			gif.Clear ();
		}
		#endregion

		#region Algorithm implementation
		public void startup(){
			IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>> output_value_instance = (IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>>)Output_messages.Instance;
			IEnumerator<int> V = g.vertexSet ().GetEnumerator ();
			while (V.MoveNext ()) {
				int v = V.Current;
				if (!isGhost(v)) {
					ICollection<int> vneighbors = g.neighborsOf (v);
					foreach (int w in vneighbors) {
						if (v < w) { //buscam-se os vérices maiores
							if (isGhost(w)) {
								IKVPairInstance<IVertexBasic,IDataTriangle> item = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
								IVertexBasicInstance ok = (IVertexBasicInstance)item.Key;
								IDataTriangleInstance ov = (IDataTriangleInstance)item.Value;
								ok.Id = w;
								ov.V = v;
								output_value_instance.put (item);
							} else {

//								IList<KeyValuePair<int,int>> l;
//								if(!triangles.TryGetValue(v, out l)){
//									l = new List<KeyValuePair<int,int>> ();
//									triangles[v] = l;
//								}

								IEnumerator<int> wneighbors = g.iteratorNeighborsOf (w);
								while (wneighbors.MoveNext ()) {
									int z = wneighbors.Current;
									if (w < z && vneighbors.Contains (z)) {

//										l.Add (new KeyValuePair<int,int> (w, z));

										count++;
									}
								}
							}
						}
					}
				}
			}
		}

		public void input_messages(){
			IKVPairInstance<IVertexBasic,IIterator<IDataTriangle>> input_values_instance = (IKVPairInstance<IVertexBasic,IIterator<IDataTriangle>>)Input_values.Instance;
			IVertexBasicInstance ikey = (IVertexBasicInstance)input_values_instance.Key;
			IIteratorInstance<IDataTriangle> ivalues = (IIteratorInstance<IDataTriangle>)input_values_instance.Value;
			IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>> output_value = (IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>>)Output_messages.Instance;

			object o; int w = ikey.Id;
			while (ivalues.fetch_next (out o)) {
				if (this.Superstep == 0)
					this.graph_creator ((IInputFormatInstance)((IDataTriangleInstance)o).Value);
				else {
					int v = ((IDataTriangleInstance)o).V;
					int z = ((IDataTriangleInstance)o).W;
					IEnumerator<int> wneighbors = g.iteratorNeighborsOf (w);
					while (wneighbors.MoveNext ()) {
						int zw = wneighbors.Current;
						if (w < zw) {
							if (z == 0) {
								IKVPairInstance<IVertexBasic,IDataTriangle> item = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
								IVertexBasicInstance ok = (IVertexBasicInstance)item.Key;
								IDataTriangleInstance ov = (IDataTriangleInstance)item.Value;
								ok.Id = v;
								ov.V = w;
								ov.W = zw;
								output_value.put (item);
							} else {
//								IList<KeyValuePair<int,int>> l;
//								if (!triangles.TryGetValue (w, out l)) {
//									l = new List<KeyValuePair<int,int>> ();
//									triangles [w] = l;
//								}
								if (z == zw) {
//									l.Add (new KeyValuePair<int,int> (v, zw));
									count++;
								}
							}
						}
					}
				}
			}
		}

		public void gust0(){
			if (this.Superstep == 0)
				this.startup ();
			else 
				if (this.Superstep == 2) {//(++iteration) == 3) {
					IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>> output_value_instance = (IIteratorInstance<IKVPair<IVertexBasic,IDataTriangle>>)Output_messages.Instance;

					output_value_instance.finish (); // obs

					IKVPairInstance<IVertexBasic,IDataTriangle> item = (IKVPairInstance<IVertexBasic,IDataTriangle>)Output_messages.createItem ();
					((IVertexBasicInstance)item.Key).Id = partid;//count;//verificar qual id
					((IDataTriangleInstance)item.Value).V = count;
					output_value_instance.put (item);
				}
		}//private int iteration = 1;
		#endregion
	}
}
