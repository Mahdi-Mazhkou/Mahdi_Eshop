using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.BaseRepositories
{
    public  interface IBaseRepositorySearchable<TModel,TKey,TSearchModel,TSearchResult>:IBaseRepository<TModel,TKey>
    {
        List<TSearchResult> Search(TSearchModel s,out int RecordCount);
    }
}
