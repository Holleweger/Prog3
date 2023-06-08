using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalleryApp.Droid;
using GalleryApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public class PhotoImporter : IPhotoImporter
{
    private bool hasCheckedPermission;
    private string[] result;

    [Obsolete]
    public bool ContinueWithPermission(bool granted)
    {
        if (!granted)
        {
            return false;
        }
        Android.Net.Uri imageUri =
        MediaStore.Images.Media.ExternalContentUri;
        var cursor =
        Application.Context.ContentResolver.Query(
            imageUri, 
            null, 
            MediaStore.IMediaColumns.MimeType + "=? or " + MediaStore.IMediaColumns.MimeType + "=?",
            new string[] { "image/jpeg", "image/png" },
            MediaStore.IMediaColumns.DateModified);

        
        
        var paths = new List<string>();
        while (cursor.MoveToNext())
        {
            string path = cursor.GetString(cursor.GetColumnIndex(
             MediaStore.Images.ImageColumns.Data));
            paths.Add(path);
        }
        result = paths.ToArray();
        hasCheckedPermission = true;
        return true;
    }

    Task<ObservableCollection<Photo>> Get(int startIndex,
    int count, Quality quality = Quality.Low)
    {
        throw new NotImplementedException();
    }
    Task<ObservableCollection<Photo>> Get(List<string> filenames,
    Quality quality = Quality.Low)
    {
        throw new NotImplementedException();
    }

    Task<ObservableCollection<Photo>> IPhotoImporter.Get(int start, int count, Quality quality)
    {
        throw new NotImplementedException();
    }

    Task<ObservableCollection<Photo>> IPhotoImporter.Get(List<string> filenames, Quality quality)
    {
        throw new NotImplementedException();
    }
}