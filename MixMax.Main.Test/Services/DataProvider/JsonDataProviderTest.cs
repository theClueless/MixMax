using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MixMax.Main.Common;
using MixMax.Main.Services.DataProvider;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Test.Services.DataProvider
{
    [TestClass]
    public class JsonDataProviderTest
    {
        [TestMethod]
        public void Set_StandardScenario_SetSuccessfuly()
        {
            DataRepository dataRepository = new DataRepository
            {
                Package = GeneratePackage(),
                Tracks = GenerateTracks(),
            };

            var mockFileHandler = new Mock<IFileHandler>();
            var expectedJson = Properties.Resources.JsonDataProviderTestExpectedResult;                

            const string filePath = @"C:\MixMax";
            JsonDataProvider jdp = new JsonDataProvider(filePath, mockFileHandler.Object);
            jdp.Set(dataRepository); 
            mockFileHandler.Verify(x => x.WriteAllText(filePath, expectedJson), Times.Once);
        }

        [TestMethod]
        public void Get_StandardScenario_SetSuccessfuly()
        {
            // Arrange
            var mockFileHandler = new Mock<IFileHandler>();
            var Json = Properties.Resources.JsonDataProviderTestExpectedResult;
            const string filePath = @"C:\MixMax";
            mockFileHandler.Setup(x => x.ReadAllText(filePath)).Returns(Json);
            JsonDataProvider jdp = new JsonDataProvider(filePath, mockFileHandler.Object);
            DataRepository dataRepository = new DataRepository
            {
                Package = GeneratePackage(),
                Tracks = GenerateTracks(),
            };

            // Act
            var res = jdp.Get();

            // Assert
            AssertHelper.AreEqualDeep(res, dataRepository);
        }

        [TestMethod]
        public void Get_FailToReadFile_ReturnsEmptyRepository()
        {
            // Arrange
            DataRepository emptyDR = new DataRepository();
            var mockFileHandler = new Mock<IFileHandler>();
            const string filePath = @"C:\MixMax";
            mockFileHandler.Setup(x => x.ReadAllText(filePath)).Throws(new FileNotFoundException());
            JsonDataProvider jdp = new JsonDataProvider(filePath, mockFileHandler.Object);

            // Act
            var res = jdp.Get();

            // Assert
            AssertHelper.AreEqualDeep(res, emptyDR);
        }


        private List<Track> GenerateTracks()
        {
            return new List<Track>
            {
                new Track
                {
                    AddedOn = new DateTime(2016,1,1),
                    DoesLike = true,
                    Id = 1,
                    LastUpdateCount = 5,
                    ThreeMonthCount = 3,
                    TotalCount = 5,
                    WasEverInAPlaylist = false,
                    FilePath = @"C:\lolz",
                    Tag = new MP3Tag { Name = "aa", Album = "a", Artist = "the a's" },
                },
                new Track
                {
                    AddedOn = new DateTime(2016,1,1),
                    DoesLike = true,
                    Id = 1,
                    LastUpdateCount = 5,
                    ThreeMonthCount = 3,
                    TotalCount = 5,
                    WasEverInAPlaylist = false,
                    FilePath = @"C:\lolz",
                    Tag = new MP3Tag { Name = "a", Album = "a", Artist = "the a's" },
                },
                new Track
                {
                    AddedOn = new DateTime(2016,1,1),
                    DoesLike = true,
                    Id = 1,
                    LastUpdateCount = 5,
                    ThreeMonthCount = 3,
                    TotalCount = 5,
                    WasEverInAPlaylist = false,
                    FilePath = @"C:\lolz",
                    Tag = new MP3Tag { Name = "aaa", Album = "a", Artist = "the a's" },
                },
            };

     
        }

        private Package GeneratePackage()
        {
            return new Package
            {
                AllPlaylists = new List<Playlist>
                {
                    new Playlist
                    {
                        Name = "Discover",
                        TrackListId = new List<int>
                        {
                            1,2,3,4,5,6,7,8
                        }
                    },
                    new Playlist
                    {
                        Name = "Oldies",
                        TrackListId = new List<int>
                        {
                            1,2,9,10
                        }
                    },
                },
                BlackList = new Playlist
                {
                    Name = "Blacklist",
                    TrackListId = new List<int> { 8, 12, 15}
                }
            };
        }
    }

    /// <summary>
    /// The assert helper allow deep equal of objects
    /// </summary>
    internal static class AssertHelper
    {
        private static readonly CompareLogic Comparer;

        static AssertHelper()
        {
            Comparer = new CompareLogic();
        }

        /// <summary>
        /// Perform a deep compare of any two .NET objects using reflection.
        /// </summary>
        /// <param name="expected">Expected object.</param>
        /// <param name="actual">Actual object.</param>
        public static void AreEqualDeep(object expected, object actual)
        {
            var res = Comparer.Compare(expected, actual);
            if (res.AreEqual) return;
            Assert.Fail(res.DifferencesString);
        }

        /// <summary>
        /// Run an action and assert if a specific exception was thrown
        /// </summary>
        /// <typeparam name="TException">type of the exception</typeparam>
        /// <param name="action">the action to preform</param>
        /// <param name="message">message of the exception, if not null would be asserted against the exception message</param>
        public static void AssertThrows<TException>(Action action, string message = null) where TException : Exception
        {
            AssertThrowsImpl<TException>(action, message);
        }

        /// <summary>
        /// Run an action and assert if a specific exception was thrown
        /// </summary>
        /// <typeparam name="TException">
        /// type of the exception
        /// </typeparam>
        /// <param name="action">
        /// the action to preform
        /// </param>
        /// <param name="verifyFunc">
        /// The verify Function
        /// </param>
        public static void AssertThrows<TException>(Action action, Func<TException, bool> verifyFunc) where TException : Exception
        {
            AssertThrowsImpl(action, null, verifyFunc);
        }

        /// <summary>
        /// Run an action and assert if a specific exception was thrown
        /// </summary>
        /// <typeparam name="TException">
        /// type of the exception
        /// </typeparam>
        /// <param name="action">
        /// the action to preform
        /// </param>
        /// <param name="verifyFunc">
        /// The verify Function
        /// </param>
        public static void AssertThrowsAggragted<TException>(Action action, Func<TException, bool> verifyFunc = null) where TException : Exception
        {
            AssertThrowsImpl(action, null, verifyFunc, true);
        }

        /// <summary>
        /// Run an action and assert if a specific exception was thrown
        /// </summary>
        /// <typeparam name="TException">
        /// type of the exception
        /// </typeparam>
        /// <param name="action">
        /// the action to preform
        /// </param>
        /// <param name="message">
        /// message of the exception, if not null would be asserted against the exception message
        /// </param>
        /// <param name="verifyFunc">
        /// The verify Function
        /// </param>
        /// <param name="isAggragte">is aggragate</param>
        private static void AssertThrowsImpl<TException>(Action action, string message = null, Func<TException, bool> verifyFunc = null, bool isAggragte = false) where TException : Exception
        {
            try
            {
                action();
                Assert.Fail($"Expected exception of type {typeof(TException)}");
            }
            catch (AggregateException aggEx) when (isAggragte == true)
            {
                // Expected
                var ex = aggEx.GetBaseException() as TException;
                Assert.IsNotNull(ex, $"Inner exception is: {aggEx.GetBaseException().GetType().Name} ,instead of:{typeof(TException)}");

                if (!string.IsNullOrEmpty(message))
                {
                    Assert.AreEqual(message, ex.Message);
                }

                if (verifyFunc != null)
                {
                    Assert.IsTrue(verifyFunc(ex), "Fail to verify Exception");
                }
            }
            catch (TException ex)
            {
                // Expected
                if (!string.IsNullOrEmpty(message))
                {
                    Assert.AreEqual(message, ex.Message);
                }

                if (verifyFunc != null)
                {
                    Assert.IsTrue(verifyFunc(ex), "Fail to verify Exception");
                }
            }
            catch (Exception ex)
            {
                // not expected
                Assert.Fail("Wrong exception type: {0} instead of: {1}, message: {2}", ex.GetType(), typeof(TException), ex.Message);
            }
        }
    }
}
