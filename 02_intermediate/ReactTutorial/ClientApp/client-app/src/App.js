import { NavLink, Route, Routes } from 'react-router-dom'
import { Home } from './pages/Home'
import { Department } from './pages/Department'
import { Employee } from './pages/Employee'

function App() {
  return (
    <>
      <div className="App container">
        <h3 className="d-flex justify-content-center m-3">
          리액트 튜토리얼
        </h3>

        <nav className="navbar navbar-expand-sm bg-light navbar-dark">
          <ul className="navbar-nav">
            <li className="nav-item"><NavLink to="/" className="btn btn-success">Home</NavLink></li>&nbsp;
            <li className="nav-item"><NavLink to="/department" className="btn btn-success">Department</NavLink></li>&nbsp;
            <li className="nav-item"><NavLink to="/employee" className="btn btn-success">Employee</NavLink></li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/department" element={<Department />} />
          <Route path="/employee" element={<Employee />} />
        </Routes>
      </div>
    </>
  );
}

export default App;