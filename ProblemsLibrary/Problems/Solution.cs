using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProblemsLibrary.Problems
{
    public static class Solution
    {
        public static List<Slide> CreateSolution(Photo[] photos)
        {
            var list = new List<Slide>();
            var usedPhotos = new HashSet<Photo>();
            var lastTags = photos[0].Tags;
            usedPhotos.Add(photos[0]);
            for (var i = 0; i < photos.Length; i++)
            {
                if (photos[0])

                if (usedPhotos.Contains(photos[i]))
                {
                    continue;
                }
                for (var j = i + 1; j < photos.Length; j++)
                {
                    if (usedPhotos.Contains(photos[j]))
                    {
                        continue;
                    }
                    foreach (var tag in lastTags)
                    {
                        if (photos[j].Tags.Contains(tag) && photos[i].Orientation == 'H' && photos[j].Orientation == 'H')
                        {
                            list.Add(new Slide { Photos = new[] { photos[i] } });
                            list.Add(new Slide { Photos = new[] { photos[j] } });
                            usedPhotos.Add(photos[i]);
                            usedPhotos.Add(photos[j]);
                            lastTags = photos[j].Tags.ToList();
                        }
                        else if (photos[j].Tags.Contains(tag) && photos[i].Orientation == 'V' &&
                                 photos[j].Orientation == 'V')
                        {
                            list.Add(new Slide { Photos = new[] { photos[i], photos[j] } });
                            usedPhotos.Add(photos[i]);
                            usedPhotos.Add(photos[j]);
                            lastTags = photos[i].Tags.Intersect(photos[j].Tags).ToList();
                        }
                    }
                }
            }

            return list;
        }

    }
}

public class Slide
{
    public IEnumerable<Photo> Photos { get; set; }
}

public class Photo
{
    public ICollection<string> Tags { get; set; }
    public char Orientation { get; set; }
    public int Id { get; set; }

    public Photo()
    {
        this.Tags = new Collection<string>();
    }

    public Photo(char orientation, ICollection<string> tags, int id)
    {
        this.Orientation = orientation;
        this.Tags = tags;
        this.Id = Id;
    }
}

