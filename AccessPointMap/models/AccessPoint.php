<?php
class AccessPoint {
    //Database info
    private $connection;
    private $tablename = "accesspoints";

    //Model param
    public $bssid;
    public $ssid;
    public $freq;
    public $signalLevel;
    public $latitude;
    public $longitude;

    //Construc that connects with the db
    public function __construct($db) {
        $this->connection = $db;
    }

    public function add() {
        $query = "INSERT INTO " . $this->tablename . " SET bssid=:bssid, ssid=:ssid, freq=:freq, signalLevel=:signalLevel, latitude=:latitude, longitude=:longitude";
    
        $stmt = $this->connection->prepare($query);

        //Deleted html tags
        $this->bssid = htmlspecialchars(strip_tags($this->bssid)); 
        $this->ssid = htmlspecialchars(strip_tags($this->ssid));
        $this->freq = htmlspecialchars(strip_tags($this->freq));
        $this->signalLevel = htmlspecialchars(strip_tags($this->signalLevel));
        $this->latitude = htmlspecialchars(strip_tags($this->latitude));
        $this->longitude = htmlspecialchars(strip_tags($this->longitude));

        //Assign the value
        $stmt->bindParam(":bssid", $this->bssid);
        $stmt->bindParam(":ssid", $this->ssid);
        $stmt->bindParam(":freq", $this->freq);
        $stmt->bindParam(":signalLevel", $this->signalLevel);
        $stmt->bindParam(":latitude", $this->latitude);
        $stmt->bindParam(":longitude", $this->longitude);

        //Execute the query
        if($stmt->execute()) {
            return true;
        }
        return false;
    }

    public function read() {
        //Selectd all data from the AccessPoint table
        $query = "SELECT * FROM " . $this->tablename;

        $stmt = $this->connection->prepare($query);
        $stmt->execute();

        return $stmt;
    }

    public function update() {
        //Update query
        $query = "UPDATE " . $this->tablename . " SET signalLevel = :signalLevel, latitude = :latitude, longitude = :longitude WHERE bssid = :bssid";

        $stmt = $this->connection->prepare($query);

        //Delete html tags
        $this->bssid=htmlspecialchars(strip_tags($this->bssid));
        $this->signalLevel=htmlspecialchars(strip_tags($this->signalLevel));
        $this->latitude=htmlspecialchars(strip_tags($this->latitude));
        $this->longitude=htmlspecialchars(strip_tags($this->longitude));

        //Bind param
        $stmt->bindParam(":bssid", $this->bssid);
        $stmt->bindParam(":signalLevel", $this->signalLevel);
        $stmt->bindParam(":latitude", $this->latitude);
        $stmt->bindParam(":longitude", $this->longitude);

        //execute query
        if($stmt->execute()) {
            return true;
        }
        return false;
    }
}
?>