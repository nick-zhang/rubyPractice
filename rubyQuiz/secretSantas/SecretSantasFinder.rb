class SecretSantasFinder
	
	def find players
    mails = players.values.sort_by {rand}    
    i = 0
	  players.each_key do |key|
      players[key] = mails[i]
      i+=1
    end 
	  players
  end
  
end