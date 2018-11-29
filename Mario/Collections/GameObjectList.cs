using Game1;
using Mario.GameObjects.Block;
using Mario.Interfaces.GameObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mario.Collections
{
	//needs to guarantee no aliasing between lists
	public class GameObjectList : IEnumerable
	{
        private static IDictionary<Type, List<IGameObject>> gameObjectListsByType;

		public GameObjectList()
		{
     
        }
        public void Initial()
        {
            gameObjectListsByType = new Dictionary<Type, List<IGameObject>>{
                {typeof(IBackground), new List<IGameObject>() },
                {typeof(IItem),new List<IGameObject>() },
                {typeof(IBlock), new List<IGameObject>() },
                {typeof(IPipe), new List<IGameObject>() },
                {typeof(IProjectile), new List<IGameObject>() },
                {typeof(IEnemy), new List<IGameObject>() },
                {typeof(IMario),new List<IGameObject>() }
            };
        }
        public void DisplayElementsToConsole()
		{
			Debug.WriteLine("Entries in  list: " + gameObjectListsByType.Count);
			foreach (KeyValuePair<Type, List<IGameObject>> pair in gameObjectListsByType)
			{
				Debug.WriteLine(pair.Key.ToString() + ", " + pair.Value.Count);
			}
		}
		public void Add(IGameObject obj)
		{
			Type gameObjectInheritorType = typeof(IGameObject);
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(obj.GetType()))
				{
					gameObjectInheritorType = typeListPair.Key;
					break;
				}
			}
			gameObjectListsByType[gameObjectInheritorType].Add(obj);
		}

		public void AddListByType(Type T, IList<IGameObject> gameObjectList)
		{
			gameObjectListsByType[T].AddRange(gameObjectList);
		}
		public void Remove(IGameObject obj)
		{
			Type gameObjectInheritorType = typeof(IGameObject);
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(obj.GetType())) {
					gameObjectInheritorType = typeListPair.Key;
					break;
				}
			}
			gameObjectListsByType[gameObjectInheritorType].Remove(obj);
		}

		//requires specific IGameObject subinterface
		public int Count(Type T)
		{
			return gameObjectListsByType[T].Count;
		}
		public IGameObject GetGameObject(IGameObject target)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(target.GetType()))
				{
					try
					{
						return (typeListPair.Value[typeListPair.Value.IndexOf(target)]);
					}
					catch (IndexOutOfRangeException)
					{
						throw new IndexOutOfRangeException();
					}
				}
			}
			return null;
		}
		public void SetGameObject(IGameObject target, IGameObject value)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(target.GetType()))
				{
					try
					{
						typeListPair.Value[typeListPair.Value.IndexOf(target)] = value;
					}
					catch (IndexOutOfRangeException)
					{
						throw new IndexOutOfRangeException();
					}
				}
			}
		}

		public bool HasObject(IGameObject target)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(target.GetType()))
				{
					try
					{
						return typeListPair.Value.IndexOf(target)>0 ;
					}
					catch (IndexOutOfRangeException)
					{
						throw new IndexOutOfRangeException();
					}
				}
			}
			return false;
		}
		public IGameObject SwapGameObject(IGameObject target, IGameObject value)
		{
			IGameObject temp = GetGameObject(target);
			SetGameObject(target, value);
			return temp;
		}
		public IGameObject Peek(Type T)
		{
			IGameObject obj = null;
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(T))
				{
					try
					{
						obj = gameObjectListsByType[typeListPair.Key][0];
						break;
					}
					catch (IndexOutOfRangeException)
					{
						throw new IndexOutOfRangeException();
					}
				}
			}
			return obj;
		}
		public override string ToString()
		{
			return base.ToString();
		}
		public void SetSingleton(Type T, IGameObject obj)
		{
			foreach (KeyValuePair<Type, List<IGameObject>> typeListPair in gameObjectListsByType)
			{
				if (typeListPair.Key.IsAssignableFrom(T))
				{
					try
					{
						gameObjectListsByType[typeListPair.Key][0] = obj;
						break;
					}
					catch (IndexOutOfRangeException)
					{
						throw new IndexOutOfRangeException();
					}
				}
			}
		}
		public IEnumerator GetEnumerator()
		{
			return new GameObjectEnumerator();
		}

		public IEnumerator GetEnumeratorByType(Type T)
		{
			if (!typeof(IGameObject).IsAssignableFrom(T))
			{
				Debug.WriteLine("nonvalid enum type");
			}
			return new GameObjectEnumeratorByType(T);
		}

		public class GameObjectEnumerator : IEnumerator
		{
			int currentIndex;
			IEnumerator<KeyValuePair<Type,List<IGameObject>>> gameObjectTypesEnumerator;
			public GameObjectEnumerator()
			{
				gameObjectTypesEnumerator = gameObjectListsByType.GetEnumerator();
				if (gameObjectTypesEnumerator.MoveNext())
				{
					currentIndex = gameObjectListsByType[gameObjectTypesEnumerator.Current.Key].Count;
				}
			}
			public object Current => gameObjectListsByType[(gameObjectTypesEnumerator.Current.Key)][currentIndex];
			

			public void Dispose()
			{
				throw new NotImplementedException();
			}

			public bool MoveNext()
			{
				bool hasNext;
				do
				{
					hasNext = false;
					do
					{
						currentIndex--;
					} while (currentIndex >= gameObjectListsByType[gameObjectTypesEnumerator.Current.Key].Count);
					if (currentIndex < 0)
					{
						hasNext = gameObjectTypesEnumerator.MoveNext();
						if (!hasNext)
						{
							return false;
						}
						//what is the state of this on failure? Probably last count of last list, -1?
						currentIndex = gameObjectListsByType[(gameObjectTypesEnumerator.Current.Key)].Count;
					}
				}while (hasNext);
				return true;
			}

			public void Reset()
			{
				currentIndex = gameObjectListsByType[gameObjectTypesEnumerator.Current.Key].Count;
                gameObjectTypesEnumerator.Reset();
            }

		}
		public class GameObjectEnumeratorByType : IEnumerator
		{
			
			private int currentIndex;
			private Type type;

			public GameObjectEnumeratorByType( Type type)
			{
				this.type = type;
				this.currentIndex = gameObjectListsByType[type].Count;
			}

			public object Current
			{
				get
				{
					try
					{
						return gameObjectListsByType[type][currentIndex];
					}
					catch (ArgumentOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}

			public bool MoveNext()
			{
				do
				{
					currentIndex--;
				} while (currentIndex >= gameObjectListsByType[type].Count);
				return (currentIndex >= 0);
			}

			public void Reset()
			{
				currentIndex = gameObjectListsByType[type].Count;
			}
		}

	}


}
