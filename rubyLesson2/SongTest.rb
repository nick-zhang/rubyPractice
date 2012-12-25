require './Song'
require './SongMore'
require './SongList'
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
    
    def testClassAttribute
      song1 = Song.new("Happy Christmas!", "Nick", 30)
      song2 = Song.new("One Love!", "Carry", 130)
      
      song1.play
      song2.play
    end
  
  def testSongListClassMethod
    song1 = Song.new("One Love!", "Carry", 130)
    assert !(SongList.isTooLong song1)
    
    song2 = Song.new("One Love!", "Carry", 350)
    assert SongList.isTooLong song2    
  end
    
end