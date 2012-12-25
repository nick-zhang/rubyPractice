class Song

  @@plays = 0
  
  def printArtist 
    puts @artist
  end

  def play
    @@plays += 1
    puts "played:#{@@plays} times!"
  end
  
end

