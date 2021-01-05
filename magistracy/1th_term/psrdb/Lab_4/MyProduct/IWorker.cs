using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorker
{
    public interface IWorker
    {
        Worker find();

        List<Worker> findAll();
    }
}
