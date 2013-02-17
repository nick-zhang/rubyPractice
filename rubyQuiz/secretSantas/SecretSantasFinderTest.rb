require './SecretSantasFinder'
require 'minitest/autorun'

class SecretSantasFinderTest < MiniTest::Unit::TestCase
  
  def setup
    @players = {"Luke Skywalker" =>   "<luke@theforce.net>",
              "Leia Skywalker"  => "<leia@therebellion.org>",
              "Toula Portokalos" => "<toula@manhunter.org>", 
              "Gus Portokalos" => "<gus@weareallfruit.net>",
              "Bruce Wayne" => "<bruce@imbatman.com>",
              "Virgil Brigman"  => "<virgil@rigworkersunion.org>",
              "Lindsey Brigman" => "<lindsey@iseealiens.net>"
              }
    @santasFinder = SecretSantasFinder.new()
  end
  
  def testShouldFindSantansForTwoPlayers
    players = {"Luke Skywalker" =>   "<luke@theforce.net>",
              "Toula Portokalos" => "<toula@manhunter.org>", 
              }
    
    santas = @santasFinder.find(players)
    assert_equal "<luke@theforce.net>", santas["Toula Portokalos"]
  end
  
  def testShouldFindSantansForMultiplePlayers
    santas = @santasFinder.find(@players)
    refute_equal "<luke@theforce.net>",santas["Luke Skywalker"] 
    refute_equal "<leia@therebellion.org>",santas["Leia Skywalker"] 
    refute_equal "<toula@manhunter.org>",santas["Toula Portokalos"]
    refute_equal "<gus@weareallfruit.net>",santas["Gus Portokalos"] 
    refute_equal "<bruce@imbatman.com>",santas["Bruce Wayne"] 
    refute_equal "<virgil@rigworkersunion.org>",santas["Virgil Brigman"] 
    refute_equal "<lindsey@iseealiens.net>",santas["Lindsey Brigman"]      
  end
   
  def testPeopleFromTheSameFamilyCanNotBeTheirSantas
    santas = @santasFinder.find(@players)
    refute_equal "<luke@theforce.net>",santas["Luke Skywalker"] 
    # refute_equal "<luke@theforce.net>",santas["Leia Skywalker"] 
    # refute_equal "<leia@therebellion.org>",santas["Leia Skywalker"] 
    # refute_equal "<leia@therebellion.org>",santas["Luke Skywalker"] 
  end
  
  def testShouldTellWetherTheFamilyNameIsTheSame
    name1 = "Luke Skywalker"
    name2 = "Leia Skywalker"
    assert @santasFinder.hasSameFamilyName name1, name2 
  end 

  def testShouldTellWetherTheFamilyNameIsNotTheSame
    name1 = "Luke Skywalker"
    name2 = "Lindsey Brigman"
    refute @santasFinder.hasSameFamilyName name1, name2 
  end
   
end