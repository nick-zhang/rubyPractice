require './Song'
require './SongMore'
require 'minitest/autorun'

class SongTest < MiniTest::Unit::TestCase

  def testSongInitializeAndAddMoreFeaturesDynamically
    song = Song.new("Happy Christmas!", "Nick", 30)
    puts song.printName
    puts song.printArtist
  end

end