require '../src/KaraokeSong' 
require 'minitest/autorun'

class KaraokeSongTest < MiniTest::Unit::TestCase

  def testKaraokSongLyrics
    song = KaraokeSong.new("Happy Christmas!", "Nick", 30)
    song.lyrics
  end

end