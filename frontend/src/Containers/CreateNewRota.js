import React, { Component } from 'react';
import DatePicker from 'react-datepicker'
import moment from 'moment'
import { addNewRota } from '../api'
import 'react-datepicker/dist/react-datepicker.css'
import { Button } from 'react-bootstrap'

export default class CreateNewRota extends Component {
  constructor(props) {
    super(props)

    this.state = {
      startDate: moment()
    }

    this.handleChange = this.handleChange.bind(this)
    this.handleOnCreate = this.handleOnCreate.bind(this)
  }

  handleChange(date) {
    this.setState({
      startDate: date
    })

    this.validateDate(date)
  }

  handleOnCreate() {
    if (this.validateDate(this.state.startDate)) {
      this.props.onApiCallStarted()
      addNewRota(this.state.startDate.toISOString())
        .then(() => this.props.onRotaCreated())
    }
  }

  validateDate(date) {
    if (moment() >= date) {
      this.setState({ error: 'You must select a date in the future.' })
      return false
    } else {
      this.setState({ error: '' })
      return true
    }
  }

  render() {
    return (
      <div>
        <p>Looks like no rota is created at the moment. Please provide an end date and create a new rota:</p>
        <DatePicker dateFormat="DD/MM/YYYY" selected={this.state.startDate} onChange={this.handleChange} />
        <Button className="create-rota-button" onClick={this.handleOnCreate}>Create</Button>
        { 
          this.state.error &&
          <div className="warning-text">{this.state.error}</div> 
        }
      </div>
    );
  }
}