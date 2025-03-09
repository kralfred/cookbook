using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Common.Models;

namespace CookBook.BL.Facades.Interfaces;

public interface IFacade<TListModel, TDetailModel>
    where TListModel : IModel
    where TDetailModel : class, IModel
{
    void Delete(Guid id);
    TDetailModel? Get(Guid id);
    IEnumerable<TListModel> Get();
    TDetailModel Save(TDetailModel model);
}
