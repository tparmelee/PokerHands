import React, { Component } from 'react';
import * as cardDeck from 'deck-o-cards';
import './App.css';
import Player from './Poker/Player';

class App extends Component {

  constructor(props) {
    super(props);

    let players = [
      { key: "Debbie", position: "TBD", handRank: "TBD", cards: [] },
      { key: "Charles", position: "TBD", handRank: "TBD", cards: [] },
      { key: "Henry", position: "TBD", handRank: "TBD", cards: [] },
    ]
    players = this.dealPlayersNewCards(players);

    this.state = {
      players: players
    }

    this.requestPokerHandAnalysis = this.requestPokerHandAnalysis.bind(this);
    this.dealNewHand = this.dealNewHand.bind(this);
  }

  componentDidMount() {
    this.requestPokerHandAnalysis();
  }

  requestPokerHandAnalysis() {
    const players = this.state.players;

    const request = players.map((player) =>
      ({
        Name: player.key,
        Cards: player.cards.map((card) => this.convertRankForFetchAPI(card.rank) + this.convertSuitForFetchAPI(card.suit))
      }
      ));

    const apiRoot = process.env.REACT_APP_API_URL ? process.env.REACT_APP_API_URL : '';
    
    fetch(apiRoot + '/api/PokerHand', {
      method: 'POST',
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(request)
    })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        throw new Error("Error occured fetching from server. " + response.statusText + "(" + response.status + ")")
      }
    })
    .then((data) => {
      let newState = this.state;
      newState.players.forEach((player) => {
        const matchingData = data.filter(element => element.name === player.key)[0];

        player.handRank = matchingData.handType;
        player.position = matchingData.position;
      })

      this.setState(newState);
    })
      .catch(err => console.error(err));
  }

  dealNewHand() {

    let newState = this.state;
    let players = newState.players;
    newState.players = this.dealPlayersNewCards(players);
    this.setState(newState);

    this.requestPokerHandAnalysis();
  }

  dealPlayersNewCards(players) {
    let newDeck = cardDeck.randomizedDeck();

    players.forEach(function (player) {
      player.cards = [];
      player.position = "TBD";
      player.handRank = "TBD";
    });

    for (let i = 0; i < 5; i++) {

      for (let j = 0; j < players.length; j++) {

        let card = newDeck.pop();

        let suit = this.convertSuitForPlayerElement(card[0]);
        let rank = this.convertRankForPlayerElement(card[1]);
        players[j].cards.push({ suit: suit, rank: rank })
      }
    }

    return players;
  }

  convertRankForFetchAPI(rank) {
    switch (rank) {
      case (2):
        return "2";
      case (3):
        return "3";
      case (4):
        return "4";
      case (5):
        return "5";
      case (6):
        return "6";
      case (7):
        return "7";
      case (8):
        return "8";
      case (9):
        return "9";
      case (10):
        return "10";
      case (11):
        return "J";
      case (12):
        return "Q";
      case (13):
        return "K";
      case (1):
        return "A";
      default:
        return "ER";
    }
  }

  convertSuitForFetchAPI(suit) {
    switch (suit) {
      case (0):
        // Club
        return "C";
      case (1):
        // Diamond
        return "D";
      case (2):
        // Heart
        return "H";
      case (3):
        // Spade
        return "S";
      default:
        return -1;
    }
  }

  convertRankForPlayerElement(rank) {
    switch (rank) {
      case ('Two'):
        return 2;
      case ('Three'):
        return 3;
      case ('Four'):
        return 4;
      case ('Five'):
        return 5;
      case ('Six'):
        return 6;
      case ('Seven'):
        return 7;
      case ('Eight'):
        return 8;
      case ('Nine'):
        return 9;
      case ('Ten'):
        return 10;
      case ('Jack'):
        return 11;
      case ('Queen'):
        return 12;
      case ('King'):
        return 13;
      case ('Ace'):
        return 1;
      default:
        return -1;
    }
  }

  convertSuitForPlayerElement(suit) {
    switch (suit) {
      case ("♠️"):
        // Spade
        return 3;
      case ("♣️"):
        // Club
        return 0;
      case ("❤️"):
        // Heart
        return 2;
      case ("♦️"):
        // Diamond
        return 1;
      default:
        return -1;
    }
  }

  render() {

    const people = this.state.players.map(element => <Player key={element.key} name={element.key}
      handRank={element.handRank} position={element.position} cards={element.cards} />);

    return (
      <div className="App">
        <h1>Poker Hands Sample Project</h1>
        <button onClick={this.dealNewHand}>Deal New Hand</button>
        {people}
      </div>
    );
  }
}

export default App;
