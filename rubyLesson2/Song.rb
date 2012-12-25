class Song
  def initialize(name, artist, duration)
    puts "In Song Initialize"
    @name = name
    @artist = artist
    @duration = duration
  end
  def lyrics
    puts "The lyrics for Song."
  end
end

class Song
  def name 
    @name
  end
  
  def artist
    @artist
  end
  
  attr_reader :duration
  
  def printName 
    puts @name
  end
end

