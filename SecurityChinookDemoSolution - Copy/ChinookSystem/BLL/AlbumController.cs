using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional NameSpaces
using ChinookSystem.Entities;
using ChinookSystem.DAL;
using ChinookSystem.ViewModels;
using System.ComponentModel;

#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        #region Queries


        //due to the fact that the entities are internal you CANNOT use the entity class as a return data type
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using (var context = new ChinookSystemContext())
            {
                //Linq to Entity
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name
                                                    };
                return results.ToList();
            }
        }
        public List<ArtistAlbums> Albums_GetAlbumsForArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                //Linq to Entity
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    where x.ArtistId == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name,
                                                        ArtistID = x.ArtistId
                                                    };
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                 select new AlbumItem
                                                 {
                                                     AlbumId = x.AlbumId,
                                                     Title = x.Title,
                                                     ArtistId = x.ArtistId,
                                                     ReleaseYear = x.ReleaseYear,
                                                     ReleaseLabel = x.ReleaseLabel


                                                 };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlbumItem Albums_FindById(int albumId)
        {
            using (var context = new ChinookSystemContext())
            {
                             AlbumItem results = (from x in context.Albums
                                                 where x.AlbumId == albumId
                                                 select new AlbumItem
                                                 {
                                                     AlbumId = x.AlbumId,
                                                     Title = x.Title,
                                                     ArtistId = x.ArtistId,
                                                     ReleaseYear = x.ReleaseYear,
                                                     ReleaseLabel = x.ReleaseLabel
                                                 }).FirstOrDefault();
                return results;
            }
        }
        #endregion
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Albums_Add(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //we need to move the data from the viewmodel class into an entity instance BEFORE staging 

                //context.Albums.Add(item);
                //context.SaveChanges();
                //since I have an int the return datatype I will return the new identity value
                //return item.AlbumId;
                Album entityItem = new Album
                {
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };
                //Stagging
                context.Albums.Add(entityItem);
                //at this point, the new PK value is NOT available the new OK value is created by the database
                //commit is the action of sending your request to the database for action
                //Also, any validation annotation in your entity definition class is executed during this command (context.SaveChanges();)
                context.SaveChanges();
                return entityItem.AlbumId;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Albums_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                //the PK of the Albums table is an Identity() PK
                //   Therefore you do NOT need to supply the AlbumId value

                //on update you NEED to supply the table's PK value
                Album entityItem = new Album
                {
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };
                context.Entry(entityItem).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();


                #region Add, Update, Delete

                #endregion
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Albums_Delete(AlbumItem item)        
        {
            //this method will call the actual delete method and pass it 
            //the only need piece of data : PK
            Albums_Delete(item.AlbumId);
        }
        public void Albums_Delete(int albumid)
        {
            using(var context = new ChinookSystemContext())
            {
                var exists = context.Albums.Find(albumid);
                context.Albums.Remove(exists);
                context.SaveChanges();
            }

        }
    } 
}