#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IfShows.Models;
using HtmlAgilityPack;
namespace IfShows.Controllers
{



    [Route("api/Show")]
    [ApiController]
    public class ShowController : ControllerBase
    {





        [Route("GetScrapedDates")]
        [AcceptVerbs("GET")]
        public async Task<List<string>> GetScrapedDates()
        {
            List<string> DateList = new List<string>();
            string link = "https://www.illusion-force.com/live";
            string Xpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            var Web = new HtmlWeb();
            var Dock = Web.Load(link);
            var Nodes = Dock.DocumentNode.SelectNodes(Xpath);

            foreach (var Node in Nodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[1]/span/span/span/span/span").InnerText;

                    DateList.Add(name);
                }
                catch
                {
                    Console.WriteLine("empty");
                }
            }

            return DateList;
        }

        [Route("GetScrapedNames")]
        [AcceptVerbs("GET")]
        public async Task<List<string>> GetScrapedNames()
        {
            List<string> NameList = new List<string>();
            string link = "https://www.illusion-force.com/live";
            string Xpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            var Web = new HtmlWeb();
            var Dock = Web.Load(link);
            var Nodes = Dock.DocumentNode.SelectNodes(Xpath);

            foreach (var Node in Nodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[2]/span/span/span/span/span").InnerText;

                    NameList.Add(name);
                }
                catch
                {
                    try
                    {
                        string name = Node.SelectSingleNode("p[1]/span[2]/span/span/span/span").InnerText;

                        NameList.Add(name);
                    }
                    catch
                    { }
                }

            }

            return NameList;
        }

        [Route("GetScrapedShows")]
        [AcceptVerbs("GET")]
        public async Task<List<Show>> GetScrapedShows()
        {
            List<Show> ShowList = new List<Show>();
            List<string> NameList = new List<string>();
            List<string> DateList = new List<string>();
            List<string> LocationList = new List<string>();
            List<string> WebsiteList = new List<string>();
            List<string> TicketList = new List<string>();
            List<string> PriceList = new List<string>();
            List<string> ActList = new List<string>();
            string link = "https://www.illusion-force.com/live";
            string NameXpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            string LocationXpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            string WebsiteXpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            string TicketXpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            var Web = new HtmlWeb();
            int counter = 1;
            var Dock = Web.Load(link);
            var NameNodes = Dock.DocumentNode.SelectNodes(NameXpath);
            string DateXpath = "/html/body/div/div/div[3]/div/main/div/div/div/div[2]/div/div/div/section[2]/div[2]/div/div[2]/div/div[position()>0]";
            var DateNodes = Dock.DocumentNode.SelectNodes(DateXpath);
            var LocationNodes = Dock.DocumentNode.SelectNodes(LocationXpath);
            var WebsiteNodes = Dock.DocumentNode.SelectNodes(WebsiteXpath);
            foreach (var Node in NameNodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[2]/span/span/span/span/span").InnerText;

                    NameList.Add(name);
                }
                catch
                {
                    try
                    {
                        string name = Node.SelectSingleNode("p[1]/span[2]/span/span/span/span").InnerText;

                        NameList.Add(name);
                    }
                    catch
                    { }
                }

            }

            foreach (var Node in DateNodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[1]/span/span/span/span/span").InnerText;

                    DateList.Add(name);
                }
                catch
                {
                    Console.WriteLine("empty");
                }
            }
            foreach (var Node in LocationNodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[4]/span/span/span/text()").InnerText;

                    LocationList.Add(name);
                }
                catch
                {
                    try
                    {
                        {
                            string name = Node.SelectSingleNode("p[5]/span/span/span/text()").InnerText;
                            LocationList.Add(name);
                        }
                    }
                    catch {
                        try
                        {

                            string name = Node.SelectSingleNode("p[3]/span/span/span/span/text()[3]").InnerText;
                            LocationList.Add(name);

                        }
                        catch { }
                    }
                }
                
                
            }
            foreach (var Node in WebsiteNodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[4]/span/span/span/span/span/a").InnerText;

                    WebsiteList.Add(name);
                }
                catch
                {
                    try
                    {

                        string name = Node.SelectSingleNode("p[5]/span/span/span/span[2]/a").InnerText;
                        WebsiteList.Add(name);

                    }
                    catch { }
                }
            }
            
            foreach (var Node in DateNodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[8]/span/span/span/span").InnerText;

                    PriceList.Add(name);
                }
                catch
                {
                    try
                    {

                        string name = Node.SelectSingleNode("p[7]/span/span[1]/span/span").InnerText;
                        PriceList.Add(name);

                    }
                    catch { }
                }
            }
            foreach (var Node in DateNodes)
            {
                try
                {
                    string name = Node.SelectSingleNode("p[9]/span[1]/span[2]/span/span/text()[2]").InnerText;

                    ActList.Add(name);
                }
                catch
                {
                    try
                    {

                        string name = Node.SelectSingleNode("p[7]/span/span[2]/span/span/text()[2]").InnerText;
                        ActList.Add(name);

                    }
                    catch { }
                }
            }


            using (var e1 = NameList.GetEnumerator())
            using (var e2 = DateList.GetEnumerator())
            using (var e3 = LocationList.GetEnumerator())
            using (var e4 = WebsiteList.GetEnumerator())
            
            using (var e6 = PriceList.GetEnumerator())
            using (var e7 = ActList.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext() && e4.MoveNext() && e6.MoveNext() && e7.MoveNext())
                {
                    var item1 = e1.Current;
                    var item2 = e2.Current;
                    var item3 = e3.Current;
                    var item4 = e4.Current;
                    
                    var item6 = e6.Current;
                    var item7 = e7.Current;
                    var show = new Show
                    {
                        Name = item1,
                        Date = item2,
                        Location = item3,
                        Website = item4,
                        
                        Price = item6,
                        Act = item7
                    };
                    ShowList.Add(show);
                }
                return ShowList;
            }
            return ShowList;





        }

        private readonly ShowContext _context;

        public ShowController(ShowContext context)
        {
            _context = context;
        }

        // GET: api/Show
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShows()
        {
            return await _context.Shows.ToListAsync();
        }

        // GET: api/Show/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        // PUT: api/Show/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.Id)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Show
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

        // DELETE: api/Show/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
