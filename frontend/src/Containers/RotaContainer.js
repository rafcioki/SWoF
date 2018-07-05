import React, { Component } from 'react'
import { GetRota } from '../api'
import CreateNewRota from './CreateNewRota'
import DeleteRota from './DeleteRota'
import Rota from '../Components/Rota'

import Spinner from 'react-spinkit'

export default class RotaContainer extends Component {
  constructor(props) {
    super(props)

    this.state = { 
      rotaDoesntExist: false,
      rota: null,
      loading: true
    }

    this.onRotaCreated = this.onRotaCreated.bind(this)
    this.onRotaDeleted = this.onRotaDeleted.bind(this)
    this.onApiCallStarted = this.onApiCallStarted.bind(this)
  }

  componentDidMount() {
    this.getRota()
  }

  onRotaCreated() {
    this.getRota()
  }

  onRotaDeleted() {
    this.setState({ rotaDoesntExist: true, loading: false })
  }

  onApiCallStarted() {
    this.setState({ loading: true })
  }

  getRota() {
    this.setState({ loading: true })

    GetRota().then(result => {
      if (result === 404) {
        this.setState({ rotaDoesntExist: true })
      } else {
        this.setState({ rotaDoesntExist: false, rota: result })
      }

      this.setState({ loading: false })
    })
  }

  render() {
    return (
      <div>
        { 
          this.state.loading &&
          <Spinner className='loading-indicator' name='three-bounce' /> 
        }

        { 
          !this.state.loading && this.state.rotaDoesntExist && 
          <CreateNewRota onRotaCreated={this.onRotaCreated} onApiCallStarted={this.onApiCallStarted} /> 
          }
        { 
          !this.state.loading && !this.state.rotaDoesntExist && 
          <div>
            <Rota rota={this.state.rota} />
            <DeleteRota onRotaDeleted={this.onRotaDeleted} onApiCallStarted={this.onApiCallStarted} />
          </div> 
        }
      </div>
    )
  }
}