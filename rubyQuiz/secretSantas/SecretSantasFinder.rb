class SecretSantasFinder
	
	public 
	def find players
	  originalMails = players.values
    mails = players.values.sort_by {rand} 
    mails = players.values.sort_by {rand} until compareMails originalMails, mails
    
    i = 0
	  players.each_key do |key|
      players[key] = mails[i]
      i+=1
    end 
	  players
  end
  
  private 
  def compareMails originalMails, currentMails
    originalMails.each_with_index do |mail, i|
      return false if mail == currentMails[i]
    end
    return true
  end
  
  def hasSameFamilyName name1, name2
    return name1.split(" ").last == names.split(" ").last
  end
  
end