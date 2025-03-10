namespace ClassLibraryTrophy.Tests {
    [TestClass()]
    public class TrophyTests {
        Trophy? trophy;

        [TestInitialize]
        public void Initializer(){
            trophy = new("FastCoding", 2024);
        }

        [TestMethod()]
        public void TestTrophyCompetionLengthLowerThanThreeException() {
            string? exceptionTest = "Ab";
            Assert.ThrowsException<ArgumentException>(() => new Trophy(exceptionTest,2024));
        }

        [TestMethod()]
        public void TestTrophyCompetitionNullException() {
            Assert.ThrowsException<ArgumentNullException>(() => new Trophy(null,2024));
        }

        [TestMethod()]
        public void TestTrophyYearLowerThan1970Exception() {
            Assert.ThrowsException<ArgumentException>(() => new Trophy("FastCoding",1969));
        }

        [TestMethod()]
        public void TestTrophyYearHigherThan2025Exception() {
            Assert.ThrowsException<ArgumentException>(() => new Trophy("FastCoding",2026));
        }

        [TestMethod()]
        public void TropyhyToStringTest() {
            string? shouldBe = "Trophy 0\nCompetition FastCoding\nYear 2024";
            Assert.AreEqual(shouldBe, trophy?.ToString());
        }
    }
}
