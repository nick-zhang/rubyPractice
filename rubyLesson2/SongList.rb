require './Song'

class SongList

  MAX_TIME = 5 * 60
  
  def SongList.isTooLong song
    return song.duration > MAX_TIME
  end
  
end

