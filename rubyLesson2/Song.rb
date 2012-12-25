class Song
  def initialize(name, artist, duration)
    puts "In Initialize"
    @name = name
    @artist = artist
    @duration = duration
  end
end

class Song
  def printName 
    puts @name
  end
end

