﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.Contracts.Requests;

public record DeleteMovieRequest(
    Guid Id
);

