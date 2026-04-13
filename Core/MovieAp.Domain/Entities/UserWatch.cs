using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class UserWatch
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public bool IsWatched { get; set; }

        public DateTime WatchedDate { get; set; }
    }
}
