import axios from "axios";
import useAuth from "./useAuth";
import config from "../config.json";

const useRefreshToken = () => {
  const { auth, setAuth } = useAuth();
  const link = `${config.API_BASE_URL}/api/token/refresh`;

  const refresh = async () => {
    try {
      const config = {
        headers: {
          "Content-Type": "application/json",
        },
      };

      const res = await axios.post(link, auth.token, config);
      if (res.status === 200) {
        setAuth((prev) => {
          const newAuth = { ...prev };
          newAuth.token = res.data.token;
          //window.localStorage.removeItem("token");
          //window.localStorage.setItem("token", JSON.stringify(res.data.token));
          return { ...newAuth };
        });
        return res.data.token;
      } else {
        return auth.token;
      }
    } catch (err) {
      console.log(err.message);
    }
  };
  return refresh;
};

export default useRefreshToken;
