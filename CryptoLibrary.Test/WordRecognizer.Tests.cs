﻿using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace CryptoLibrary.Test
{
    [TestFixture]
    public class WordRecognizerTests
    {
        private List<string> _combinedDictionary = new List<string>();

        [TestFixtureSetUp]
        public void LoadDictionary()
        {
            var dictionaryDirectory = Directory.EnumerateFiles(@"..\..\wordlists\");
            foreach (string dictionaryFile in dictionaryDirectory)
            {
                var lines = File.ReadAllLines(dictionaryFile);
                _combinedDictionary.AddRange(lines);
            }
        }

        [Test]
        public void ShouldNotFindWordMissingFromDictionary()
        {
            var wordDictionary = new List<string>
            {
                "the",
                "quick",
                "brown",
                "fox",
                "jumped",
                "over",
                "lazy",
                "dog"
            };

            var wordRecognizer = new WordRecognizer(wordDictionary);

            Assert.IsNullOrEmpty(wordRecognizer.ContainsDictionaryWord("floof"));
        }

        [Test]
        public void ShouldFindWorPresentInDictionary()
        {
            var wordDictionary = new List<string>
            {
                "the",
                "quick",
                "brown",
                "fox",
                "jumped",
                "over",
                "lazy",
                "dog"
            };

            var wordRecognizer = new WordRecognizer(wordDictionary);

            Assert.IsNullOrEmpty(wordRecognizer.ContainsDictionaryWord("jump3e"));
        }

        [Test]
        public void ShouldFindWordInFullDictionary()
        {
            var wordRecognizer = new WordRecognizer(_combinedDictionary);
            Assert.AreEqual("lynchpin", wordRecognizer.ContainsDictionaryWord("lynchpin"));
        }

        [Test]
        public void ShouldNotFindNonWordInFullDictionary()
        {
            var wordRecognizer = new WordRecognizer(_combinedDictionary);
            Assert.AreEqual(null, wordRecognizer.ContainsDictionaryWord("lynchpinz"));
        }
    }
}
