require './Song'

class KaraokeSong < Song
  def initialize(name, artist, duration)
    super(name, artist, duration)
    puts "In KaraokeSong Initialize"
  end
  
  def lyrics
    super
    puts "The lyrics for KaraokSong."
  end
end

