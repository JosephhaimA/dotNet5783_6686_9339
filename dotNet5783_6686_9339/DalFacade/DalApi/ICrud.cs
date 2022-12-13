using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface ICrud<T> where T : struct
{
    int Add(T obj);
    T GetObj(int id);
    void Delete(int id);
    void Update(T obj);
    IEnumerable<T?>? GetAll(Func<T?,bool>? func = null);
    T GetSingle(Func<T?, bool>? func);
}
