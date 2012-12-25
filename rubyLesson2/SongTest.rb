require './Song'
require './SongMore'
require 'minitest/autorun'

class SongTest < MiniTest::Unit::TestCase

  def testSongInitializeAndAddMoreFeaturesDynamically
    song = Song.new("Happy Christmas!", "Nick", 30)
    puts song.printName
    puts song.printArtist
    song.lyrics
  end
  
  def testAccessSongAttributes
    song = Song.new("Happy Christmas!", "Nick", 30)
    assert_equal "Happy Christmas!", song.name  
    assert_equal 30, song.duration
  end

end