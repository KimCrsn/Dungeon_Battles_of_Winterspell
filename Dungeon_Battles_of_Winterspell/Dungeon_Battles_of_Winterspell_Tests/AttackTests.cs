using Dungeon_Battles_of_Winterspell;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dungeon_Battles_of_Winterspell_Tests
{
    [TestClass]
    public class AttackTests
    {
        /// <summary>
        /// Making sure that the array used for damage ranges is properly created
        /// </summary>
        [TestMethod]
        public void DamageRangeProducesExpectedArray()
        {
            // Arrange
            Combat sut = new Combat();

            // Act 
            int[] result = sut.DamageRange();

            // Assert
            Assert.IsTrue(result.Length == 25);
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[24] == 25);
        }
    }
}
