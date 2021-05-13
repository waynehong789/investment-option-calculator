import Button from '@material-ui/core/Button';
import { useHistory } from 'react-router-dom';
// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
const login = () => {
    const history = useHistory();
    const handleClick = () => history.push('/calculator');
    return (
        <div>
            Login Page is working
            <Button variant="contained" color="primary" onClick={handleClick}>
                Login
            </Button>
        </div>
    );
};

export default login;
