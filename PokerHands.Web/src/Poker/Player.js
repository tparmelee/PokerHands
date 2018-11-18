import React, { Component } from 'react';
import { Hand } from 'react-deck-o-cards';

class Player extends Component {

    render() {
        const defHandStyle = {
            maxHeight: '34vh',
            minHeight: '8vh',

            maxWidth: '50vw',
            padding: 0,
        };

        // const cardsToRender = this.props.cards.map(element => { rank: element.ran, suit: element.suit});
        
        return <div>
            <h3>Player Name: {this.props.name}</h3>
            <p>Position: {this.props.position} </p>
            <p>Hand: {this.props.handRank}</p>
            <div>
                <Hand cards={[
                    { rank: this.props.cards[0].rank, suit: this.props.cards[0].suit},
                    { rank: this.props.cards[1].rank, suit: this.props.cards[1].suit},
                    { rank: this.props.cards[2].rank, suit: this.props.cards[2].suit},
                    { rank: this.props.cards[3].rank, suit: this.props.cards[3].suit},
                    { rank: this.props.cards[4].rank, suit: this.props.cards[4].suit}
                ]} hidden={false} style={defHandStyle} />
            </div>
        </div>
    }
}

export default Player;