import React from "react";
import Container from 'react-bootstrap/esm/Container';
import Col from "react-bootstrap/esm/Col";
import Row from 'react-bootstrap/esm/Row';
import {Program} from './components/ListUsers'

const App = () => {

  return (
    <Container>
      <Row>
        <Col className='col-12'>
          <Program />
        </Col>
      </Row>
      <Row>
        <Col className='col-12'>
          {/* <Pagination size="lg">{items}</Pagination> */}
        </Col>
      </Row>
    </Container>
  );
};

export default App;