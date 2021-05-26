using System;
using NUnit.Framework;

namespace JensUngerer.BitVector64.Test
{
    public class BitVector64Test
    {
        private static long[] masks = BitVector64.createMasks();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitalisationsAndSettingOneBit()
        {
            // Arrange
            var bitVector = new BitVector64();
            int bitIndexToSet = 5;

            // Act
            bitVector[masks[bitIndexToSet]] = true;

            // Assert
            Assert.AreEqual(true, bitVector[masks[bitIndexToSet]]);
            for (int i = 0; i < BitVector64.NUMBER_OF_BITS_IN_BITVECTOR64; i++)
            {
                if (i != bitIndexToSet)
                {
                    Assert.AreEqual(false, bitVector[masks[i]]);
                }
            }

            // Act
            bitVector[masks[bitIndexToSet]] = false;

            // Assert
            for (int i = 0; i < BitVector64.NUMBER_OF_BITS_IN_BITVECTOR64; i++)
            {
                Assert.AreEqual(false, bitVector[masks[i]]);
            }
        }


        [Test]
        public void SettingWithInvalidBitMask()
        {
            // Arrange
            long wrongMask = unchecked((long)0x8000000000000000);

            // Act && Assert
            var throwingDelegate = new TestDelegate(() =>
            {
                BitVector64.CreateMask(wrongMask);
            });
            Assert.Throws<InvalidOperationException>(throwingDelegate);
        }
    }
}