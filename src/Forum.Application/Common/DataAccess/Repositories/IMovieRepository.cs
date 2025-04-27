using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Common.DataAccess.Repositories.Common.Actions;
using Forum.Application.Common.DataAccess.Repositories.Common.Base;

namespace Forum.Application.Common.DataAccess.Repositories;

public interface IMovieRepository : IRepository<MovieEntity>, 
                                    IGetByIdRepositoryAction<MovieEntity>,
                                    IInsertRepositoryAction<MovieEntity>,
                                    IGetAllRepositoryAction<MovieEntity>,
                                    IDeleteByIdRepositoryAction,
                                    IUpdateRepositoryAction<MovieEntity>
{
}
