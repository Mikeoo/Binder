﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Binder.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
