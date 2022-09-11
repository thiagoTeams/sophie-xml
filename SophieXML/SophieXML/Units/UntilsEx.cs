using System;
using System.Runtime.InteropServices;

namespace SophieXML.Units
{
    public static class UntilsEx
    {
        public static OSPlatform GetSystemType()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //if (_env.IsDevelopment())
                //{
                //    context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "Utils/NativeLibrary/libwkhtmltox", "libwkhtmltox.dylib"));
                //}
                //else
                //{
                //    string path = Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dylib");
                //    if (File.Exists(path))
                //    {
                //        context.LoadUnmanagedLibrary(path);
                //    }
                //    else
                //    {
                //        path = Path.Combine(Directory.GetCurrentDirectory(), "Utils/NativeLibrary/libwkhtmltox", "libwkhtmltox.dylib");
                //        context.LoadUnmanagedLibrary(path);
                //    }
                //}

                return OSPlatform.OSX;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //if (_env.IsDevelopment())
                //{
                //    context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "Utils/NativeLibrary/libwkhtmltox", "libwkhtmltox.so"));
                //}
                //else
                //{
                //    string path = Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.so");
                //    if (File.Exists(path))
                //    {
                //        context.LoadUnmanagedLibrary(path);
                //    }
                //    else
                //    {
                //        path = Path.Combine(Directory.GetCurrentDirectory(), "Utils/NativeLibrary/libwkhtmltox", "libwkhtmltox.so");
                //        context.LoadUnmanagedLibrary(path);
                //    }
                //}

                return OSPlatform.Linux;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //if (_env.IsDevelopment())
                //{
                //    context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "Utils/NativeLibrary/libwkhtmltox", "libwkhtmltox.dll"));
                //}
                //else
                //{
                //    string path = Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll");
                //    if (File.Exists(path))
                //    {
                //        context.LoadUnmanagedLibrary(path);
                //    }
                //    else
                //    {
                //        path = Path.Combine(Directory.GetCurrentDirectory(), "Utils/NativeLibrary/libwkhtmltox", "libwkhtmltox.dll");
                //        context.LoadUnmanagedLibrary(path);
                //    }
                //}

                return OSPlatform.Windows;
            }

            return OSPlatform.FreeBSD;
        }
    }
}

