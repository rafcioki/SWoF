import React, { Component } from 'react'
import { deleteExistingRota } from '../api'
import { Button } from 'react-bootstrap'

export default class DeleteRota extends Component {
  constructor(props) {
    super(props)

    this.state = { isConfirmingDelete: false }

    this.handleOnDelete = this.handleOnDelete.bind(this)
    this.renderDeleteConfirmation = this.renderDeleteConfirmation.bind(this)
    this.confirmDelete = this.confirmDelete.bind(this)
    this.cancelDelete = this.cancelDelete.bind(this)
  }

  handleOnDelete() {
    this.setState({ isConfirmingDelete: true })
  }

  confirmDelete() {
    this.props.onApiCallStarted()
    deleteExistingRota().then(() => this.props.onRotaDeleted())
  }

  cancelDelete() {
    this.setState({ isConfirmingDelete: false })
  }

  renderDeleteConfirmation() {
    return (
      <div className="delete-rota-confirmation">
        <p className="warning-text">Are you sure? This action is irreversible.</p>
        <Button className="confirm-deleting-rota-button" bsStyle="danger" onClick={this.confirmDelete}>Confirm</Button>
        <Button onClick={this.cancelDelete}>Cancel</Button>
      </div>
      )
  }

  render() {
    return (
      <div>
        {
          this.state.isConfirmingDelete ? 
            this.renderDeleteConfirmation() :
            <Button className="delete-rota-button" bsStyle="danger" onClick={this.handleOnDelete}>Delete rota</Button>
        }
      </div>
    );
  }
}