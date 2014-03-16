using System;
using System.Collections.Generic;

namespace CUDA_Administrator.Nvidia_API.Collections
{
    public interface IReadOnlyArray<T> : IEnumerable<T>
    {

        T this[int index] { get; }

        int Length { get; }

    }
}
