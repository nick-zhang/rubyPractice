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
  end
  
  def testShouldFindSantansForTwoPlayers
    players = {"Luke Skywalker" =>   "<luke@theforce.net>",
              "Leia Skywalker"  => "<leia@therebellion.org"
              }
    
    santasFinder = SecretSantasFinder.new()
    santas = santasFinder.find(players)
    assert_equal "<luke@theforce.net>", santas["Leia Skywalker"]
  end

end