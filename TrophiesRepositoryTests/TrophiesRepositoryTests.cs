namespace ClassLibraryTrophy.Tests {
    [TestClass()]
    public class TrophiesRepositoryTests {
        TrophiesRepository? repo;

        [TestInitialize]
        public void Initializer(){
            repo = new();

            //Added in the trophiesrepository contructor
            /*trophies.Add(new Trophy("Marathon", 2021));*/
            /*trophies.Add(new Trophy("Ironman", 2022));*/
            /*trophies.Add(new Trophy("FastCoding", 2022));*/
            /*trophies.Add(new Trophy("FastCoding", 2023));*/
            /*trophies.Add(new Trophy("FastCoding", 2024));*/
        }

        [TestMethod()]
        public void TestIds(){
            Assert.AreEqual(1,repo?.Get()?[0].Id);
            Assert.AreEqual(2,repo?.Get()?[1].Id);
            Assert.AreEqual(3,repo?.Get()?[2].Id);
            Assert.AreEqual(4,repo?.Get()?[3].Id);
            Assert.AreEqual(5,repo?.Get()?[4].Id);
        }

        [TestMethod()]
        public void TrophyRepoGetTest() {
            Assert.IsNotNull(repo?.Get()?.ToList());

            Assert.AreNotEqual(4,repo?.Get()?.Count);
            Assert.AreEqual(5,repo?.Get()?.Count());
            Assert.AreNotEqual(6,repo?.Get()?.Count);

            Assert.AreNotEqual(1,repo?.Get(year: 2022)?.Count);
            Assert.AreEqual(2,repo?.Get(year: 2022)?.Count);
            Assert.AreNotEqual(3,repo?.Get(year: 2022)?.Count);

            Assert.ThrowsException<ArgumentException>(() => repo?.Get(year: 1969));
            Assert.ThrowsException<ArgumentException>(() => repo?.Get(year: 2026));

            Assert.AreEqual("FastCoding",repo?.Get(sortByAscending: "Competition")?[0].Competition);
            Assert.AreEqual("Marathon",repo?.Get(sortByDescending: "Competition")?[0].Competition);

            Assert.AreEqual(2021,repo?.Get(sortByAscending: "Year")?[0].Year);
            Assert.AreEqual(2024,repo?.Get(sortByDescending: "Year")?[0].Year);

            Assert.ThrowsException<ArgumentNullException>(() => repo?.GetById(6));
        }

        [TestMethod()]
        public void ManipulateRepo(){
            Assert.ThrowsException<ArgumentNullException>(() => repo?.Add(null));

            repo?.Add(new Trophy("Football",2025));

            Assert.AreNotEqual(5, repo?.Get()?.Count());
            Assert.AreEqual(6, repo?.Get()?.Count());
            Assert.AreNotEqual(7, repo?.Get()?.Count());

            Assert.ThrowsException<ArgumentNullException>(() => repo?.Remove(10));

            Assert.AreEqual("FastCoding", repo?.Remove(5)?.Competition);

            Assert.AreNotEqual(4, repo?.Get()?.Count());
            Assert.AreEqual(5, repo?.Get()?.Count());
            Assert.AreNotEqual(6, repo?.Get()?.Count());
        }

        [TestMethod()]
        public void TestUpdate(){
            Assert.AreEqual(5,repo?.Get()?.Count());

            Assert.ThrowsException<ArgumentNullException>(() => repo?.Update(6, null));

            Trophy? updateValues = new("SlowCoding",2024);
            Assert.AreNotEqual(repo?.GetById(5)?.Competition,updateValues.Competition);

            repo?.Update(5,updateValues);

            Assert.AreEqual(repo?.GetById(5)?.Competition,updateValues.Competition);
            Assert.AreEqual(repo?.GetById(5)?.Year,updateValues.Year);
        }
    }
}
