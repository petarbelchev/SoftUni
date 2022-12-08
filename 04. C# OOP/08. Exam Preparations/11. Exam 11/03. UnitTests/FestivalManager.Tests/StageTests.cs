// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void AddPerformerNullShouldThrowException()
        {
            Stage stage = new Stage();
            Performer performer = null;

            Assert.That(() =>
            {
                stage.AddPerformer(performer);
            }, Throws.ArgumentNullException, "Can not be null!");
        }

        [Test]
        public void AddPerformerShouldThrowExceptionWhenPerformerIsUnder18()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("FirstName", "LastName", 17);

            Assert.That(() =>
            {
                stage.AddPerformer(performer);
            }, Throws.ArgumentException, "You can only add performers that are at least 18.");
        }

        [Test]
        public void AddPerformerShouldWorkCorrectly()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("FirstName", "LastName", 18);
            stage.AddPerformer(performer);

            Assert.That(stage.Performers.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSongNullShouldThrowException()
        {
            Stage stage = new Stage();
            Song song = null;

            Assert.That(() =>
            {
                stage.AddSong(song);
            }, Throws.ArgumentNullException, "Can not be null!");
        }

        [Test]
        public void AddSongShouldThrowExceptionWhenDurationIsUnder1Min()
        {
            Stage stage = new Stage();
            TimeSpan duration = new TimeSpan(0, 0, 59);
            Song song = new Song("Song", duration);

            Assert.That(() =>
            {
                stage.AddSong(song);
            }, Throws.ArgumentException, "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void AddSongToPerformerShouldWorkCorrectly()
        {
            Stage stage = new Stage();
            TimeSpan duration = new TimeSpan(0, 1, 1);
            Song song = new Song("Song", duration);
            Performer performer = new Performer("FirstName", "LastName", 18);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            string response = stage.AddSongToPerformer(song.Name, performer.FullName);

            string expectedResponse = $"{song} will be performed by {performer.FullName}";
            Assert.That(response, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void PlayShouldWorkCorrectly()
        {
            Stage stage = new Stage();
            TimeSpan duration = new TimeSpan(0, 1, 1);
            Song song = new Song("Song", duration);
            Performer performer = new Performer("FirstName", "LastName", 18);
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer(song.Name, performer.FullName);

            string response = stage.Play();
            string expectedResponse = "1 performers played 1 songs";

            Assert.That(response, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void AddSongToPerformerShouldThrowExceptionWhenPerformerDoesntExists()
        {
            Stage stage = new Stage();
            TimeSpan duration = new TimeSpan(0, 1, 1);
            Song song = new Song("Song", duration);
            Performer performer = new Performer("FirstName", "LastName", 18);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(() =>
            {
                stage.AddSongToPerformer(song.Name, "Other Performer");
            }, Throws.ArgumentException, "There is no performer with this name.");
        }

        [Test]
        public void AddSongToPerformerShouldThrowExceptionWhenSongDoesntExists()
        {
            Stage stage = new Stage();
            TimeSpan duration = new TimeSpan(0, 1, 1);
            Song song = new Song("Song", duration);
            Performer performer = new Performer("FirstName", "LastName", 18);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            Assert.That(() =>
            {
                stage.AddSongToPerformer("OtherSong", performer.FullName);
            }, Throws.ArgumentException, "There is no song with this name.");
        }
    }
}