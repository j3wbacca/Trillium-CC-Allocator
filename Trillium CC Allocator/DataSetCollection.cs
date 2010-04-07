using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;

namespace Trillium_CC_Allocation
{
    public class DataSetCollection:CollectionBase
    {
        

        #region Collection Members

        public void Add(DataSet item)
        {
            List.Add(item);
        }

        new public void Clear()
        {
            List.Clear();
        }

        public bool Contains(DataSet item)
        {
            return List.Contains(item);
        }

        public void CopyTo(DataSet[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        new public int Count
        {
            get { return List.Count; }
        }

        public bool IsReadOnly
        {
            get { return List.IsReadOnly; }
        }

        public void Remove(DataSet item)
        {
            List.Remove(item);
        }

        public DataSet this[string userName]
        {
            get
            {
                DataSet tempDS = null;

                foreach (DataSet ds in List)
                {
                    if (ds.ExtendedProperties["user"].ToString() == userName)
                    {
                        tempDS = ds;
                    }
                }

                return tempDS;
            }
            set
            {

                for (int i = 0; i < List.Count;i++ )
                {
                    if (((DataSet)List[i]).ExtendedProperties["user"].ToString() == userName)
                    {
                        List[i] = value;
                    }
                }

            }
        }

        public DataSet this[int index]
        {
            get
            {
                return (DataSet)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        #endregion

        
    }
}
