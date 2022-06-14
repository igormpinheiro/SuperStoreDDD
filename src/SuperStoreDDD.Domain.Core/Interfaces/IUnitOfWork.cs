﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStoreDDD.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task<bool> Rollback();
    }
}
