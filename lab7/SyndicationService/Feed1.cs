using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace SyndicationService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Feed1 : IFeed1
    {
        private static string FeedFormat => WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];

        private SyndicationFeed CreateBaseFeed()
        {
            var feed = new SyndicationFeed("Feed Title", "A WCF Syndication Feed", null)
            {
                Items = new List<SyndicationItem>()
                {
                    new SyndicationItem("An item", "Item content", null)
                }
            };

            return feed;
        }

        private static SyndicationFeedFormatter GetSyndicationFeedFormatterByFormat(string query, SyndicationFeed feed)
        {
            return query == "atom"
                ? (SyndicationFeedFormatter) new Atom10FeedFormatter(feed)
                : new Rss20FeedFormatter(feed);
        }

        public SyndicationFeedFormatter GetStudentNotes(string studentId)
        {
            var feedNotes = GetSyndicationFeed("Subjects & Notes", "Get list of notes by all subjects for this student", GetNotes(studentId));
            return GetSyndicationFeedFormatterByFormat(FeedFormat, feedNotes);
        }

        private SyndicationFeed GetSyndicationFeed(string title, string description, IEnumerable<Note> notes)
        {
            if (notes == null)
                return CreateBaseFeed();
            return new SyndicationFeed(title, description,
                null)
            {
                Items = notes.Select(note => new SyndicationItem(note.Subj, note.Note1.ToString(), null)).ToList()
            };
        }

        private static IEnumerable<Note> GetNotes(string studentId)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:62938/Service.svc/Notes?$filter=(StudentId%20eq%20" + studentId + ")&$format=json");
            request.Method = "GET";
            var response = (HttpWebResponse) request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            var responseString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<NoteResponse>(responseString).Value;
        }
    }
}
